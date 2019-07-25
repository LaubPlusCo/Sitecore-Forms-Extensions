using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactPersonalInfo
{
    public class XDbGenderBindingHandler : PersonalInformationBindingHandler
    {
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(PersonalInformation facet)
        {
            return string.IsNullOrEmpty(facet.Gender)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(facet.Gender);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (!(newValue is string gender)) return;
            UpdateFacet(x=>x.Gender=gender);
        }
        
    }
}