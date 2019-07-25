using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactAddress
{
    public class XDbPostalCodeBindingHandler : PreferredAddressBindingHandler
    {
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(Address addres)
        {
            return string.IsNullOrEmpty(addres.PostalCode)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(addres.PostalCode);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (newValue is string value)
            {
                UpdateFacet(x => x.PreferredAddress.PostalCode = value);
            }
        }

    }
}