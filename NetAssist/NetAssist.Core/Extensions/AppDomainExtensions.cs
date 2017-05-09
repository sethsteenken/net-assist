using System;
using System.IO;
using System.Text;

namespace NetAssist
{
    public static class AppDomainExtensions
    {
        public static string GetProjectSolutionRoot(this AppDomain domain)
        {
            return GetProjectSolutionRoot(domain,  levelsDeep: 1);
        }

        public static string GetProjectSolutionRoot(this AppDomain domain, int levelsDeep)
        {
            return GetProjectSolutionRoot(domain, levelsDeep, levelsDeepIfInBin: 2);
        }

        public static string GetProjectSolutionRoot(this AppDomain domain, int levelsDeep, int levelsDeepIfInBin)
        {
            if (domain == null)
                return null;

            var sbLevels = new StringBuilder();

            for (int i = 0; i < levelsDeep; i++)
            {
                sbLevels.Append("..\\");
            }

            var dir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, sbLevels.ToString()));

            if (levelsDeepIfInBin > 0 && (dir.EndsWith("bin") || dir.EndsWith(@"bin\")))
            {
                var sbBinLevels = new StringBuilder();
                for (int i = 0; i < levelsDeepIfInBin; i++)
                {
                    sbBinLevels.Append("..\\");
                }
                dir = Path.GetFullPath(Path.Combine(dir, sbBinLevels.ToString()));
            }

            return dir;
        }
    }
}
