using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactConcent
{
    public class XDbDoNotMarketBindingHandler : ConsentInformationBindingHandler
    {
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(ConsentInformation facet)
        {
            return new BindingValueFoundResult(facet.DoNotMarket);
        }

        public override void StoreBindingValue(object newValue)
        {
            if (!(newValue is bool value)) return;
            UpdateFacet(x => x.DoNotMarket = value);
        }
    }
}