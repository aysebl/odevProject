using System;
using System.Collections.Generic;
using System.Text;

namespace Odev.Entities.Base
{
    public interface IDocument
    {
        string Id { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime? UpdatedAt { get; set; }

        DateTime? DeletedAt { get; set; }
    }
}
