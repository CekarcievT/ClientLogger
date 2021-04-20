using ClientLogger.Business.Infrastructure;
using ClientLogger.Business.Interfaces;
using ClientLogger.Business.Models;
using System;
using System.Collections.Generic;

namespace ClientLogger.Business.Service
{
    public class ClientService: IClientService
    {
        readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository) {
            _clientRepository = clientRepository;
        }
        
        public List<ClientFullInfo> GetAllCLients()
        {
            var result = _clientRepository.GetAllClients();
            return result;
        }

        public ClientFullInfo CreateClient(ClientFullInfo clientFullInfo)
        {
            List<RuleViolation> ruleViolations = new List<RuleViolation>();
            if(String.IsNullOrEmpty(clientFullInfo.FirstName))
            {
                ruleViolations.Add(new RuleViolation("First name cannot be empty"));
            }
            if (String.IsNullOrEmpty(clientFullInfo.LastName))
            {
                ruleViolations.Add(new RuleViolation("Last name cannot be empty"));
            }
            if (String.IsNullOrEmpty(clientFullInfo.Email))
            {
                ruleViolations.Add(new RuleViolation("Email cannot be empty"));
            }
            if (String.IsNullOrEmpty(clientFullInfo.Country))
            {
                ruleViolations.Add(new RuleViolation("Country cannot be empty"));
            }
            if (String.IsNullOrEmpty(clientFullInfo.PostName))
            {
                ruleViolations.Add(new RuleViolation("Post name cannot be empty"));
            }
            if (String.IsNullOrEmpty(clientFullInfo.PostNumber))
            {
                ruleViolations.Add(new RuleViolation("Post number cannot be empty"));
            }
            if (clientFullInfo.PostNumber.Length>5)
            {
                ruleViolations.Add(new RuleViolation("Post number cannot be more than 5 digits"));
            }
            if (String.IsNullOrEmpty(clientFullInfo.Street))
            {
                ruleViolations.Add(new RuleViolation("Street cannot be empty"));
            }
            if (clientFullInfo.BirthDate == null)
            {
                ruleViolations.Add(new RuleViolation("Birth date cannot be null"));
            }
            var isNumeric = int.TryParse(clientFullInfo.PostNumber, out _);
            if (!isNumeric)
            {
                ruleViolations.Add(new RuleViolation("Post number must be numeric"));
            }
            if (ruleViolations.Count > 0)
            {
                throw new RuleViolationException(ruleViolations);
            }

            try
            {
                return _clientRepository.CreateClient(clientFullInfo);
            } 
            catch (Exception ex)
            {
                ruleViolations.Add(new RuleViolation(ex));
                throw new RuleViolationException(ruleViolations);
            }
        }

        public void UpdateClient(ClientFullInfo clientFullInfo)
        {
            List<RuleViolation> ruleViolations = new List<RuleViolation>();
            if (String.IsNullOrEmpty(clientFullInfo.FirstName))
            {
                ruleViolations.Add(new RuleViolation("First name cannot be empty"));
            }
            if (String.IsNullOrEmpty(clientFullInfo.LastName))
            {
                ruleViolations.Add(new RuleViolation("Last name cannot be empty"));
            }
            if (String.IsNullOrEmpty(clientFullInfo.Email))
            {
                ruleViolations.Add(new RuleViolation("Email cannot be empty"));
            }
            if (String.IsNullOrEmpty(clientFullInfo.Country))
            {
                ruleViolations.Add(new RuleViolation("Country cannot be empty"));
            }
            if (String.IsNullOrEmpty(clientFullInfo.PostName))
            {
                ruleViolations.Add(new RuleViolation("Post name cannot be empty"));
            }
            if (String.IsNullOrEmpty(clientFullInfo.PostNumber))
            {
                ruleViolations.Add(new RuleViolation("Post number cannot be empty"));
            }
            if (clientFullInfo.PostNumber.Length > 5)
            {
                ruleViolations.Add(new RuleViolation("Post number cannot be more than 5 digits"));
            }
            if (String.IsNullOrEmpty(clientFullInfo.Street))
            {
                ruleViolations.Add(new RuleViolation("Street cannot be empty"));
            }
            if (clientFullInfo.BirthDate == null)
            {
                ruleViolations.Add(new RuleViolation("Birth date cannot be null"));
            }
            var isNumeric = int.TryParse(clientFullInfo.PostNumber, out _);
            if (!isNumeric)
            {
                ruleViolations.Add(new RuleViolation("Post number must be numeric"));
            }
            if (ruleViolations.Count > 0)
            {
                throw new RuleViolationException(ruleViolations);
            }

            try
            {
                _clientRepository.UpdateClient(clientFullInfo);
            } 
            catch (Exception ex)
            {
                ruleViolations.Add(new RuleViolation(ex));
                throw new RuleViolationException(ruleViolations);
            }
        }

        public void DeleteClient(ClientFullInfo clientFullInfo)
        {
            List<RuleViolation> ruleViolations = new List<RuleViolation>();
            if (clientFullInfo.id == 0)
            {
                ruleViolations.Add(new RuleViolation("Birth date cannot be null"));
            }
            if (ruleViolations.Count > 0)
            {
                throw new RuleViolationException(ruleViolations);
            }

            try
            {
                _clientRepository.DeleteClient(clientFullInfo);
            } catch (Exception ex)
            {
                ruleViolations.Add(new RuleViolation(ex));
                throw new RuleViolationException(ruleViolations);
            }
        }
    }
}
