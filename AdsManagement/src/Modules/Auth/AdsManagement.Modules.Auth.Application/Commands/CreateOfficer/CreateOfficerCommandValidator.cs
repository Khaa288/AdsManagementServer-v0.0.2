using System.Runtime.CompilerServices;
using AdsManagement.Modules.Auth.Domain.Repositories;
using FluentValidation;

namespace AdsManagement.Modules.Auth.Application.Commands;

public class CreateOfficerCommandValidator : AbstractValidator<CreateOfficerCommand>
{
    public CreateOfficerCommandValidator(
        IOfficerRepository officerRepository,
        IDistrictRepository districtRepository,
        IWardRepository wardRepository)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty")
            .EmailAddress()
            .WithMessage("Email must be an valid email address")
            .MustAsync(async (request, email, cancellation) =>
            {
                var isExist = await officerRepository.IsOfficerExistsByEmailAsync(request.Email);

                return !isExist;
            })
            .WithMessage("Email already exists !");
        
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage("Full name cannot be empty");
        
        RuleFor(x => x.DoB)
            .LessThan(DateTime.Now)
            .WithMessage("Date of birth must be in the past");
        
        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\d{11}$")
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber))
            .WithMessage("Phone number must be a valid phone number");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long")
            .Matches(@"[A-Z]")
            .WithMessage("Password must contain at least one uppercase letter")
            .Matches(@"[a-z]")
            .WithMessage("Password must contain at least one lowercase letter")
            .Matches(@"\d")
            .WithMessage("Password must contain at least one digit")
            .Matches(@"[\W_]")
            .WithMessage("Password must contain at least one special character");
        
        RuleFor(x => x.RePassword)
            .Equal(x => x.Password)
            .WithMessage("Passwords do not match");

        RuleFor(x => x.DistrictId)
            .GreaterThan(0)
            .WithMessage("District Id must be greater than 0")
            .MustAsync(async (districtId,cancellation) =>
            {
                return await districtRepository.IsDistrictExistsByIdAsync(districtId);
            })
            .WithMessage("District Id is not valid");

        RuleFor(x => x.WardId)
            .MustAsync(async (command, wardId, cancellation) =>
            {
                if (command.WardId != null)
                {
                    var ward = await wardRepository.GetWardByIdAsync(command.WardId.Value);
                    if (ward is null)
                    {
                        return false;
                    }
                }

                return true;
            })
            .WithMessage("Ward is not valid.")
            .MustAsync(async (command, wardId, cancellation) =>
            {
                if (command.WardId != null)
                {
                    var ward = await wardRepository.GetWardByIdAsync(command.WardId.Value);
                    if (!ward!.DistrictId.Equals(command.DistrictId))
                    {
                        return false;
                    }
                }

                return true;
            })
            .WithMessage("The Ward does not belong to District.");
        
        RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage("Role Id is required");
        
        RuleFor(x => x.Privileges)
            .MustAsync(async (command, privileges, cancellation) =>
            {
                if (privileges.Count > 0)
                {
                    // Retrieve role with its privileges from the repository
                    var role = await roleRepository.GetRoleWithPrivilegesAsync(command.RoleId);

                    if (role == null)
                    {
                        return false; // If role doesn't exist, validation fails
                    }

                    // Set to track duplicates in the provided privileges list
                    var privilegeSet = new HashSet<int>();

                    foreach (var privilege in privileges)
                    {
                        // Check for duplicate privilege in the provided list
                        if (!privilegeSet.Add(privilege))
                        {
                            // If privilege is already in the set, it's a duplicate
                            return false; // Validation fails due to duplicate
                        }

                        // Check if the role already contains the privilege
                        if (role.Privileges.Any(rp => rp.Id == privilege))
                        {
                            // If the role already contains the privilege, ignore
                            continue;
                        }
                    }
                }

                return true; // Validation passes if all checks are okay
            })
            .WithMessage("Privileges contain duplicates or are already assigned to the role.");
    }
}