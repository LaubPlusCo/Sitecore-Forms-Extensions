using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactPersonalInfo
{
    public class XDbMiddleNameBindingHandler : PersonalInformationBindingHandler
    {
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(PersonalInformation facet)
        {
            return string.IsNullOrEmpty(facet.MiddleName)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(facet.MiddleName);
        }


        public override void StoreBindingValue(object newValue)
        {
            if (!(newValue is string middleName)) return;
            UpdateFacet(x => x.MiddleName = middleName);
        }
       
    }
}