﻿using Sitecore.XConnect.Collection.Model;

namespace Feature.FormsExtensions.Business.FieldBindings.xDbBindingHandlers.ContactAddress
{
    public abstract class PreferredAddressBindingHandler : BaseXDbBindingHandler<AddressList>
    {
        protected override string GetFacetKey()
        {
            return AddressList.DefaultFacetKey;
        }

        protected override AddressList CreateFacet()
        {
            return new AddressList(new Address(), Sitecore.Configuration.Settings.GetSetting("XDbPreferredAddress", "preferred"));
        }
        protected override IBindingHandlerResult GetFieldBindingValueFromFacet(AddressList facet)
        {
            return facet.PreferredAddress == null ? new NoBindingValueFoundResult() : GetFieldBindingValueFromFacet(facet.PreferredAddress);
        }

        protected abstract IBindingHandlerResult GetFieldBindingValueFromFacet(Address preferredAddress);

    }

}