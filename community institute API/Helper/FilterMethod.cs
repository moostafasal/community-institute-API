using System.ComponentModel.DataAnnotations;

namespace community_institute_API.Helper
{
    public class FilterMethod
    {
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public class MaxFileSizeAttribute : ValidationAttribute
        {
            private readonly int _maxFileSize;

            public MaxFileSizeAttribute(int maxFileSize)
            {
                _maxFileSize = maxFileSize;
            }

            public override bool IsValid(object value)
            {
                if (value is null)
                {
                    return true;
                }

                if (value is not IFormFile file)
                {
                    throw new ArgumentException($"Invalid argument type. Expected type '{typeof(IFormFile)}', but received '{value.GetType()}'.");
                }

                return file.Length <= _maxFileSize;
            }
        }

        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public class AllowedExtensionsAttribute : ValidationAttribute
        {
            private readonly string[] _allowedExtensions;

            public AllowedExtensionsAttribute(string[] allowedExtensions)
            {
                _allowedExtensions = allowedExtensions;
            }

            public override bool IsValid(object value)
            {
                if (value is null)
                {
                    return true;
                }

                if (value is not IFormFile file)
                {
                    throw new ArgumentException($"Invalid argument type. Expected type '{typeof(IFormFile)}', but received '{value.GetType()}'.");
                }

                var extension = Path.GetExtension(file.FileName);

                return _allowedExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase);
            }
        }

    }
}
