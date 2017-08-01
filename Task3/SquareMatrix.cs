using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class SquareMatrix<T> : IEnumerable<T>
    {
        public int Size { get; }
        protected T[,] data;

        public event EventHandler<MatrixEventArgs> ElementChanged;


        public SquareMatrix(T[,] matrix)
        {
            if (matrix.Rank != 2) throw new ArgumentException("Matrix must have two dimensions.");
            if (!IsSquare(matrix)) throw new ArgumentException("Matrix must be square.");

            Size = matrix.Length;

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    data[i, j] = matrix[i, j];
        }
        public SquareMatrix(int size)
        {
            if (size < 0) throw new ArgumentException();

            Size = size;
            data = new T[size, size];
        }
        public SquareMatrix() { }

        public virtual void SetElement(int i, int j, T value)
        {
            if (i > Size || j > Size || i < 0 || j < 0) throw new ArgumentOutOfRangeException();

            data[i, j] = value;
            OnElementChanged(new MatrixEventArgs($"[{i}][{j} element changed"));
        }

        protected virtual void OnElementChanged(MatrixEventArgs e)
        {
            ElementChanged?.Invoke(this, e);
        }

        public bool IsSquare(T[,] matrix)
        {
            return matrix.GetLength(0) == matrix.GetLength(1);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    yield return data[i, j];
        }
    }


    public class MatrixEventArgs : EventArgs
    {
        private string msg;

        public MatrixEventArgs(string s)
        {
            msg = s;
        }
    }
}
