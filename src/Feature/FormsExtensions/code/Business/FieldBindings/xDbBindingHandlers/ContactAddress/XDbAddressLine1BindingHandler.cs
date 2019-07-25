using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactAddress
{
    public class XDbAddressLine1BindingHandler: PreferredAddressBindingHandler
    {

        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(Address addres)
        {
            return string.IsNullOrEmpty(addres.AddressLine1)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(addres.AddressLine1);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (newValue is string addressLine1)
            {
                UpdateFacet(x => x.PreferredAddress.AddressLine1=addressLine1);
            }
        }

    }
}