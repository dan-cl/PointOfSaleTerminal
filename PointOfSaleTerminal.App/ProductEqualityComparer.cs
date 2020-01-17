using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PointOfSaleTerminal.App
{
    public interface IProductEqualityComparer
    {
        bool Equals(IProduct x, IProduct y);
        int GetHashCode([DisallowNull] IProduct obj);
    }

    public class ProductEqualityComparer : IEqualityComparer<IProduct>, IProductEqualityComparer
    {
        public bool Equals(IProduct x, IProduct y)
        {
            return x.ProductId.Equals(y.ProductId, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode([DisallowNull] IProduct obj)
        {
            return obj.ProductId.ToUpper().GetHashCode();
        }
    }
}
