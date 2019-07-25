using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactPersonalInfo
{
    public class XDbFirstNameBindingHandler : PersonalInformationBindingHandler
    {
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(PersonalInformation facet)
        {
            return string.IsNullOrEmpty(facet.FirstName)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(facet.FirstName);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (!(newValue is string firstName)) return;
            UpdateFacet(x=>x.FirstName=firstName);
        }
    }
}