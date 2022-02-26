using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KristofferStrube.Blazor.FileSystemAccess
{
    public class Blob
    {
        protected readonly IJSObjectReference jSReference;
        protected readonly IJSInProcessObjectReference helper;

        internal Blob(IJSObjectReference jSReference, IJSInProcessObjectReference helper)
        {
            this.jSReference = jSReference;
            this.helper = helper;
        }

        public ulong Size => helper.Invoke<ulong>("getAttribute", jSReference, "size");

        public string Type => helper.Invoke<string>("getAttribute", jSReference, "type");

        public async Task<string> TextAsync()
        {
            return await jSReference.InvokeAsync<string>("text");
        }
    }
}
