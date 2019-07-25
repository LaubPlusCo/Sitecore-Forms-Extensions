using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactPersonalInfo
{
    public class XDbLastNameBindingHandler : PersonalInformationBindingHandler
    {
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(PersonalInformation facet)
        {
            return string.IsNullOrEmpty(facet.LastName)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(facet.LastName);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (!(newValue is string lastName)) return;
            UpdateFacet(x => x.LastName = lastName);
        }
    }
}