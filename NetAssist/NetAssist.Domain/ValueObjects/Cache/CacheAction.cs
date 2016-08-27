using NetAssist.Validation;

namespace NetAssist.Domain
{
    public class CacheAction : ValueObject<CacheAction>
    {
        public CacheAction(string action, string controller)
        {
            Guard.Begin().IsNotNull(action, nameof(action)).IsNotNull(controller, nameof(controller)).Check();
            Action = action.Trim();
            Controller = controller.Trim();
        }

        public string Action { get; private set; }
        public string Controller { get; private set; }
        public virtual string Key => $"Controller={Controller.ToLowerInvariant()}Action={Action.ToLowerInvariant()}";
        public static string GetCacheKey(string action, string controller) => new CacheAction(action, controller).Key;
    }
}
