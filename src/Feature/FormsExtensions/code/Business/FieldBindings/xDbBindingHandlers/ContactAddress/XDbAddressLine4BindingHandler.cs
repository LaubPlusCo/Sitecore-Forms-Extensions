using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactAddress
{
    public class XDbAddressLine4BindingHandler : PreferredAddressBindingHandler
    {
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(Address addres)
        {
            return string.IsNullOrEmpty(addres.AddressLine4)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(addres.AddressLine4);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (newValue is string addressLine4)
            {
                UpdateFacet(x => x.PreferredAddress.AddressLine4 = addressLine4);
            }
        }
    }
}