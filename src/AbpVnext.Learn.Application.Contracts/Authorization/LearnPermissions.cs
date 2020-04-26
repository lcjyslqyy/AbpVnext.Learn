using Volo.Abp.Reflection;

namespace AbpVnext.Learn.Authorization
{
    public class LearnPermissions
    {
        public const string GroupName = "Learn";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(LearnPermissions));
        }
    }
}