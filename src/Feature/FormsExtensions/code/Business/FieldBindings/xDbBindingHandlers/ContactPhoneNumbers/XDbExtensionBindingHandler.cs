using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactPhoneNumbers
{
    public class XDbExtensionBindingHandler : PreferredPhoneNumbersBindingHandler
    {
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(PhoneNumber phoneNumber)
        {
            return string.IsNullOrEmpty(phoneNumber.Extension)
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(phoneNumber.Extension);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (!(newValue is string value)) return;
            UpdateFacet(x => x.PreferredPhoneNumber.Extension = value);
        }

    }
}