using Emergency_Skeleton.Contracts;
using Emergency_Skeleton.Enums;
using Emergency_Skeleton.Models.Emergencies;
using Emergency_Skeleton.Models.EmergencyCenters;
using Emergency_Skeleton.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Emergency_Skeleton.Core
{
    public class EmergencyManagementSystem : IEmergencyManagementSystem
    {
        private IDictionary<string, IEmergencyRegister<IEmergency>> allEmergencies;
        private IDictionary<string, IEmergencyRegister<IServiceCenter>> allServiceCenters;
        private ISet<IEmergency> processedEmergencies;

        public EmergencyManagementSystem()
        {
            this.processedEmergencies = new HashSet<IEmergency>();
            this.allEmergencies = this.InitializeAllEmergencies();
            this.allServiceCenters = this.InitializeAllServiceCenters();
        }

        
        public string EmergencyReport()
        {
            var amountOfFireServiceCenters = this.allServiceCenters[nameof(FiremanServiceCenter)].Count();
            var amountOfMedicalServiceCenters = this.allServiceCenters[nameof(MedicalServiceCenter)].Count();
            var amountOfPoliceServiceCenters = this.allServiceCenters[nameof(PoliceServiceCenter)].Count();

            var amountOfAllProcessedEmergencies = this.processedEmergencies.Count();
            var amountOfCurrentlyRegisteredEmergencies = this.allEmergencies.Sum(x => x.Value.Count());

            var amountOfTotalPropertyDamageOfAllProcessedEmergencies = this.processedEmergencies
                .Where(e => e.GetType() == typeof(PropertyEmergency))
                .Cast<PropertyEmergency>()
                .Sum(pe => pe.Damage);

            var amountOfHealthCasualtiesOfAllProcessedEmergencies = this.processedEmergencies
                .Where(e => e.GetType() == typeof(HealthEmergency))
                .Cast<HealthEmergency>()
                .Sum(he => he.NumberOfCasualties);

            var amountOfSpecialCasesProcessedFromAllProcessedEmergencies = this.processedEmergencies
                .Where(e => e.GetType() == typeof(OrderEmergency))
                .Cast<OrderEmergency>()
                .Count(oe => oe.Status == Status.Special);

            var reportBuilder = new StringBuilder()
                .AppendLine("PRRM Services Live Statistics")
                .AppendLine($"Fire Service Centers: {amountOfFireServiceCenters}")
                .AppendLine($"Medical Service Centers: {amountOfMedicalServiceCenters}")
                .AppendLine($"Police Service Centers: {amountOfPoliceServiceCenters}")
                .AppendLine($"Total Processed Emergencies: {amountOfAllProcessedEmergencies}")
                .AppendLine($"Currently Registered Emergencies: { amountOfCurrentlyRegisteredEmergencies}")
                .AppendLine($"Total Property Damage Fixed: {amountOfTotalPropertyDamageOfAllProcessedEmergencies}")
                .AppendLine($"Total Health Casualties Saved: {amountOfHealthCasualtiesOfAllProcessedEmergencies}")
                .AppendLine($"Total Special Cases Processed: {amountOfSpecialCasesProcessedFromAllProcessedEmergencies}");

            return reportBuilder.ToString().Trim();
        }

        public string ProcessEmergencies(string emergencyType)
        {
            var emergencies = this.allEmergencies[emergencyType];
            var serviceCenters = this.GetAvailableServiceCentersByName(emergencyType);

            while (!emergencies.IsEmpty() && !serviceCenters.IsEmpty())
            {
                var currentCenter = serviceCenters.PeekEmergency();

                for (int i = 0; i < currentCenter.AmountOfMaximumEmergencies; i++)
                {
                    if (!emergencies.IsEmpty())
                    {
                        var emergencyToBeProcessed = emergencies.DequeueEmergency();
                        currentCenter.AddEmergency(emergencyToBeProcessed);
                        this.processedEmergencies.Add(emergencyToBeProcessed);
                    }
                }

                if (currentCenter.IsForRetirement())
                {
                    serviceCenters.DequeueEmergency();
                }
            }

            var unprocessedEmergencies = emergencies.Count();

            if (unprocessedEmergencies == 0)
            {
                return string
                    .Format(
                        Constants.EmergenciesProcessedSuccessfully, 
                        emergencyType.Replace(Constants.EmergencySuffix, string.Empty));
            }

            return string
                    .Format(
                        Constants.EmergenciesNotProcessedSuccessfully,
                        emergencyType.Replace(Constants.EmergencySuffix, string.Empty),
                        unprocessedEmergencies);
        }

        private IEmergencyRegister<IServiceCenter> GetAvailableServiceCentersByName(string emergencyType)
        {
            var attribute = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IEmergency))
                    && !t.IsAbstract)
                .FirstOrDefault(t => t.Name == emergencyType)
                ?.GetCustomAttributes(true)
                .FirstOrDefault()
                ?.GetType();

            var serviceCenterType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IServiceCenter))
                    && !t.IsAbstract)
                .Where(t => t
                    .GetCustomAttributes(true)
                    .Select(att => att.GetType().Name)
                        .Contains(attribute.Name))
                ?.FirstOrDefault()
                ?.Name;

            return this.allServiceCenters[serviceCenterType];
        }

        public string RegisterFireServiceCenter(IServiceCenter serviceCenter)
        {
            var serviceCenterType = serviceCenter.GetType().Name;
            this.allServiceCenters[serviceCenterType].EnqueueEmergency(serviceCenter);
            return string.Format(Constants.FireServiceCenterRegistration, serviceCenter.Name);
        }

        public string RegisterHealthEmergency(IEmergency emergency)
        {
            var emergencyType = emergency.GetType().Name;
            this.allEmergencies[emergencyType].EnqueueEmergency(emergency);

            return string.Format(Constants.HealthEmergencyRegistration, emergency.Level.ToString(), emergency.Time.ToString());
        }

        public string RegisterMedicalServiceCenter(IServiceCenter serviceCenter)
        {
            var serviceCenterType = serviceCenter.GetType().Name;
            this.allServiceCenters[serviceCenterType].EnqueueEmergency(serviceCenter);
            return string.Format(Constants.MedicalServiceCenterRegistration, serviceCenter.Name);
        }

        public string RegisterOrderEmergency(IEmergency emergency)
        {
            var emergencyType = emergency.GetType().Name;
            this.allEmergencies[emergencyType].EnqueueEmergency(emergency);

            return string.Format(Constants.OrderEmergencyRegistration, emergency.Level.ToString(), emergency.Time.ToString());
        }

        public string RegisterPoliceServiceCenter(IServiceCenter serviceCenter)
        {
            var serviceCenterType = serviceCenter.GetType().Name;
            this.allServiceCenters[serviceCenterType].EnqueueEmergency(serviceCenter);
            return string.Format(Constants.PoliceServiceCenterRegistration, serviceCenter.Name);
        }

        public string RegisterPropertyEmergency(IEmergency emergency)
        {
            var emergencyType = emergency.GetType().Name;
            this.allEmergencies[emergencyType].EnqueueEmergency(emergency);

            return string.Format(Constants.PropertyEmergencyRegistration, emergency.Level.ToString(), emergency.Time.ToString());
        }

        private IDictionary<string, IEmergencyRegister<IServiceCenter>> InitializeAllServiceCenters()
        {
            var allCenters = new Dictionary<string, IEmergencyRegister<IServiceCenter>>();

            Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IServiceCenter))
                    && !t.IsAbstract)
                .Select(t => t.Name)
                .ToList()
                .ForEach(n => allCenters.Add(n, new EmergencyRegister<IServiceCenter>()));

            return allCenters;
        }

        private IDictionary<string, IEmergencyRegister<IEmergency>> InitializeAllEmergencies()
        {
            var allEmergencies = new Dictionary<string, IEmergencyRegister<IEmergency>>();

            Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IEmergency))
                    && !t.IsAbstract)
                .Select(t => t.Name)
                .ToList()
                .ForEach(n => allEmergencies.Add(n, new EmergencyRegister<IEmergency>()));

            return allEmergencies;
        }
    }
}
