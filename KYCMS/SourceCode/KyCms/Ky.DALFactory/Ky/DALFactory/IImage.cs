namespace Ky.DALFactory
{
    using Ky.Model;
    using System;

    public interface IImage
    {
        int Add(M_Image model);
        M_Image GetItem(int imgId);
        void Update(M_Image model);
    }
}

