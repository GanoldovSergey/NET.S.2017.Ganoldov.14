using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(int size) : base(size) { }
        public SymmetricMatrix(T[,] matrix) : base(matrix) { }

    }
}
