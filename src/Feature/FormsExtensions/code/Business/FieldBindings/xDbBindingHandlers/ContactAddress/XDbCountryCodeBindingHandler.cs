using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactAddress
{
    public class XDbCountryCodeBindingHandler : PreferredAddressBindingHandler
    {
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(Address addres)
        {
            return string.IsNullOrEmpty(addres.CountryCode)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(addres.CountryCode);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (newValue is string value)
            {
                UpdateFacet(x => x.PreferredAddress.CountryCode = value);
            }
        }

    }
}