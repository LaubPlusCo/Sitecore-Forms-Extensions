using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactPersonalInfo
{
    public class XDbNickNameBindingHandler : PersonalInformationBindingHandler {
        
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(PersonalInformation facet)
        {
            return string.IsNullOrEmpty(facet.Nickname)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(facet.Nickname);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (!(newValue is string nickName)) return;
            UpdateFacet(x => x.Nickname = nickName);
        }
        
    }
}