using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactPersonalInfo
{
    public class XDbBirthDateBindingHandler : PersonalInformationBindingHandler
    {
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(PersonalInformation facet)
        {
            return !facet.Birthdate.HasValue
                ? (IBindingHandlerResult) new NoBindingValueFoundResult()
                : new BindingValueFoundResult(facet.Birthdate);
        }
        
        public override void StoreBindingValue(object newValue)
        {
            if (!(newValue is System.DateTime birthDate)) return;
            UpdateFacet(x=>x.Birthdate=birthDate);
        }
        
    }
}