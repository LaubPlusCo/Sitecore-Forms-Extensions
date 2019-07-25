using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactPhoneNumbers
{
    public abstract class PreferredPhoneNumbersBindingHandler : BaseXDbBindingHandler<PhoneNumberList>
    {
        protected override string GetFacetKey()
        {
            return PhoneNumberList.DefaultFacetKey;
        }

        protected override PhoneNumberList CreateFacet()
        {
            return new PhoneNumberList(new PhoneNumber("",""), Sitecore.Configuration.Settings.GetSetting("XDbPreferredPhoneNumber", "preferred"));
        }
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(PhoneNumberList facet)
        {
            return facet.PreferredPhoneNumber == null ? new NoBindingValueFoundResult() : GetFieldBindingValueFromFacet(facet.PreferredPhoneNumber);
        }

        protected abstract IBindingHandlerResult GetFieldBindingValueFromFacet(PhoneNumber phoneNumber);

    }
}