using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactPersonalInfo
{
    public class XDbJobTitleBindingHandler : PersonalInformationBindingHandler
    {
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(PersonalInformation facet)
        {
            return string.IsNullOrEmpty(facet.JobTitle)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(facet.JobTitle);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (!(newValue is string jobTitle)) return;
            UpdateFacet( x => x.JobTitle = jobTitle);
        }
        
    }
    
}