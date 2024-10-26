using System.Runtime.CompilerServices;
using AdsManagement.Modules.Auth.Domain.Repositories;
using FluentValidation;

namespace AdsManagement.Modules.Auth.Application.Commands;

public class CreateOfficerCommandValidator : AbstractValidator<CreateOfficerCommand>
{
    public CreateOfficerCommandValidator(
        IOfficerRepository officerRepository,
        IDistrictRepository districtRepository,
        IWardRepository wardRepository,
        IRoleRepository roleRepository,
        IPrivilegeRepository privilegeRepository)
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
                    var ward = await wardRepository.GetWardByIdAsync(command.WardId);
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
                    var ward = await wardRepository.GetWardByIdAsync(command.WardId);
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
            .WithMessage("Role Id is required")
            .MustAsync(async (command, roleId, cancellation) =>
            {
                return await roleRepository.IsRoleExistsByIdAsync(command.RoleId);
            })
            .WithMessage("Role Id is not valid");
            
        RuleFor(x => x.Privileges)
            .MustAsync(async (command, privileges, cancellation) =>
            {
                if (privileges.Count > 0 && command.RoleId != null)
                {
                    foreach (var privilege in privileges)
                    {
                        if (!await privilegeRepository.IsPrivilegeExistsById(privilege) )
                        {
                            return false;
                        }
                    }
                }
            
                return true;
            })
            .WithMessage("One or more privilege IDs do not exist in the database.");
    }
}
