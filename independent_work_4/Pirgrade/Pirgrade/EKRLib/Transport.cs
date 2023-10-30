using System;
namespace EKRLib
{
    /// <summary>
    /// абстрактный класс для наследников Car и MotorBoat 
    /// </summary>
    public abstract class Transport
    {
        public string Model { get; }
        public uint Power { get; }
        /// <summary>
        /// Происходит проверка и присваивание переменых
        /// </summary>
        /// <param name="model"> модель </param>
        /// <param name="power"> мощность двигателя</param>
        /// <exception cref="TransportException"></exception>
        public Transport(string model, uint power)
        {
            if (model.Length == 5)
            {
                Model = model;
            }
            else
            {
                throw new TransportException($"Недопустимая модель {model}");
            }

            if (model.ToCharArray().All(x => ((x >= 'A') && (x <= 'Z') || (x >= '0') && (x <= '9'))))
            {
                Model = model;
            }
            else
            {
                throw new TransportException($"Недопустимая модель {model}");
            }

            Power = power > 19 ? power : throw new TransportException("мощность не может быть меньше 20 л.с");
        }

        public override string ToString()
        {
            return $"Model {Model}, Power: {Power}";
        }

        public abstract string StartEngine();

    }


}