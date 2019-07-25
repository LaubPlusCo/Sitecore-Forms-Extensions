using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactPhoneNumbers
{
    public class XDbNumberBindingHandler : PreferredPhoneNumbersBindingHandler
    {
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(PhoneNumber phoneNumber)
        {
            return string.IsNullOrEmpty(phoneNumber.Number)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(phoneNumber.Number);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (!(newValue is string value)) return;
            UpdateFacet(x => x.PreferredPhoneNumber.Number = value);
        }
        
    }
}