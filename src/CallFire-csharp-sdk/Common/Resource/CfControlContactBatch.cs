﻿namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfControlContactBatch : CfUniqueResource
    {
        public CfControlContactBatch(long id, string name, bool? enabled) : base(id)
        {
            Name = name;
            Enabled = enabled;
        }

        public string Name { get; set; }

        public bool? Enabled { get; set; }
    }
}
