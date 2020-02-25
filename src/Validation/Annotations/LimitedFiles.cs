using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Validation.Annotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class LimitedFilesAttribute : ValidationAttribute
    {
        public LimitedFilesAttribute(params string[] items)
        {
            foreach (var extension in items)
            {
                if (!extension.StartsWith("."))
                {
                    throw new ArgumentException("Invalid extension");
                }
            }

            this.Items = items;
        }

        public string[] Items { get; set; }

        public override bool IsValid(object value)
        {
            if (!( value is string fileName ))
            {
                return false;
            }

            return this.Items.Any(ext => ext == Path.GetExtension(fileName));
        }
    }
}
