﻿using System;
using Feature.FormsExtensions.Business.FileUpload;
using Feature.FormsExtensions.Fields.FileUpload;
using Sitecore.ExperienceForms.Mvc.Pipelines.ExecuteSubmit;
using Sitecore.Mvc.Pipelines;

namespace Feature.FormsExtensions.Pipelines.ExecuteSubmit
{
    public class StoreFileUploads : MvcPipelineProcessor<ExecuteSubmitActionsEventArgs>
    {
        private readonly IFileUploadStorageProviderFactory fileUploadStorageProviderFactory;

        public StoreFileUploads(IFileUploadStorageProviderFactory fileUploadStorageProviderFactory)
        {
            this.fileUploadStorageProviderFactory = fileUploadStorageProviderFactory;
        }

        public override void Process(ExecuteSubmitActionsEventArgs args)
        {
            if (args?.FormSubmitContext?.Fields == null)
            {
                return;
            }

            foreach (var field in args.FormSubmitContext.Fields)
            {
                if (!(field is FileUploadModel uploadField))
                    continue;
                HandleUploadField(uploadField,args.FormSubmitContext.FormId);
            }
        }

        private void HandleUploadField(FileUploadModel uploadField, Guid formId)
        {
            if (uploadField.File == null)
                return;

            if (uploadField.File.InputStream.Position > 0)
                return;
            
            var storedFile = fileUploadStorageProviderFactory.GetDefaultFileUploadStorageProvider().StoreFile(uploadField, formId);
            uploadField.Value = storedFile;
        }
        
    }
}