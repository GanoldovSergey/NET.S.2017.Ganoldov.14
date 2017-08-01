using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size) { }
        public DiagonalMatrix(T[,] matrix) : base(matrix.Length)
        {
            if (matrix.Rank != 2) throw new ArgumentException("Matrix must have two dimensions.");
            if (!IsSquare(matrix)||!IsDiagonal(matrix)) throw new ArgumentException("Matrix must be diagonal.");
            

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    data[i, j] = matrix[i, j];
        }
        public DiagonalMatrix(T[] diagonal) : base(diagonal.Length)
        {
            for (int i = 0; i < Size; i++)
                data[i, i] = diagonal[i];
        }


        private bool IsDiagonal(T[,] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix.Length; j++)
                    if (i != j && Equals(matrix[i, j], default(T))) return false;
            return true;
        }
    }
}
