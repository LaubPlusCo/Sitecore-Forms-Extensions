using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactPersonalInfo
{
    public class XDbSuffixBindingHandler : PersonalInformationBindingHandler
    {
        
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(PersonalInformation facet)
        {
            return string.IsNullOrEmpty(facet.Suffix)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(facet.Suffix);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (!(newValue is string suffix)) return;
            UpdateFacet(x => x.Suffix = suffix);
        }
       
    }
}