using AbpVnext.Learn.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpVnext.Learn.Authorization
{
    public class LearnPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(LearnPermissions.GroupName, L("Permission:Learn"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<LearnResource>(name);
        }
    }
}