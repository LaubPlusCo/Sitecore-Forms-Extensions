using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactAddress
{
    public class XDbCityBindingHandler : PreferredAddressBindingHandler
    {
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(Address addres)
        {
            return string.IsNullOrEmpty(addres.City)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(addres.City);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (newValue is string city)
            {
                UpdateFacet(x => x.PreferredAddress.City = city);
            }
        }

    }
}