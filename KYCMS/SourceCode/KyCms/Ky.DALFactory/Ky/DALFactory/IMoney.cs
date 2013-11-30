namespace Ky.DALFactory
{
    using System;

    public interface IMoney
    {
        void ExpireTime(int Value, int UserId);
        void Integral(int Value, int UserId);
        void YellowBoy(decimal Value, int UserId);
    }
}

