namespace AdsManagement.Modules.Report.Domain.BusinessRules;

public class ReportBusinessRule
{
    // public static bool EachReportHasTwoImages(List<string> urls)
    // {
    //     return urls.Count <= 2 ? true : false;
    // }
    
    public static bool EachReportHasTwoImages(int count)
    {
        return count <= 2 ? true : false;
    }
}