using System;

namespace Lab1KeyboasrdBiometry
{
    public class User
    {
        private String name;
        private String password;
        private long avgHoldingTime;
        private long avgSpeed;
        private Double avgErrors;
        
        //todo: можно добавить словарик с удержанием букв, но опустим пока

        public User(string name, string password, long avgHoldingTime, long avgSpeed, Double avgErrors)
        {
            this.name = name;
            this.password = password;
            this.avgHoldingTime = avgHoldingTime;
            this.avgSpeed = avgSpeed;
            this.avgErrors = avgErrors;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public long AvgHoldingTime
        {
            get => avgHoldingTime;
            set => avgHoldingTime = value;
        }

        public long AvgSpeed
        {
            get => avgSpeed;
            set => avgSpeed = value;
        }

        public long AvgErrors
        {
            get => avgErrors;
            set => avgErrors = value;
        }
    }
}