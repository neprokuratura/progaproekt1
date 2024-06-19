﻿using Microsoft.AspNetCore.Mvc;
using ShizUslugi.Models;
using ShizUslugi.Repository;
using ShizUslugi.Interfaces;
using ShizUslugi.ViewModels;
using System.Reflection.Metadata.Ecma335;
namespace ShizUslugi.Controllers
{
	public class AdminController : Controller
	{
		private readonly IAdminRepository _adminRepository;
		public AdminController(IAdminRepository adminrepository)
		{
			_adminRepository = adminrepository;
		}
		public IActionResult Index()
		{
			StaticStuff.alldiagnoses = _adminRepository.GetAllDiagnoses().ToList();
			AllAdminViewModel model = new AllAdminViewModel();
			model.doctor = StaticStuff.doctor;
			return View(model);
		}
		public IActionResult Patients()
		{
			AllAdminViewModel model = StaticStuff.adminmodel == null? new AllAdminViewModel() : StaticStuff.adminmodel;
			model.patients = _adminRepository.GetAllPatients().ToList();
			model.chambers = _adminRepository.GetAllChambers().ToList();
			/*if (StaticStuff.adminmodel != null)
			{
				model.IsEdit = StaticStuff.adminmodel.IsEdit;
				model.IsChamberOverfilled = StaticStuff.adminmodel.IsChamberOverfilled;
				model.IsInputActivate = StaticStuff.adminmodel.IsInputActivate;
				model.IsFieldEmpty = StaticStuff.adminmodel.IsFieldEmpty;
				model.IsFieldOverfilled = StaticStuff.adminmodel.IsFieldOverfilled;
				model.FieldName = StaticStuff.adminmodel.FieldName;
				model.patient = StaticStuff.adminmodel.patient;
			}*/
			return View(model);
		}
		[HttpPost]
		public IActionResult Patients(AllAdminViewModel model)
		{
		  if(_adminRepository.GetAccountsByLogin(model.account.login).Any())
			{
				model.IsUserExisting = true;
				model.IsFieldEmpty = false;
			}
			else
			{
				model.IsFieldEmpty = true;
				if (model.account.login == null)
				{
					model.FieldName = "Логин";
				}
				else if (model.account.password == null)
				{
					model.FieldName = "Пароль";
				}
				else if (model.patient.name == null)
				{
					model.FieldName = "Имя";
				}
				else if (model.patient.surname == null)
				{
				    model.FieldName = "Фамилия";
				}
				else
				{
					model.IsFieldEmpty = false;
					model.IsFieldOverfilled= true;
					if (model.account.login.Length > 20)
					{
						model.FieldName = "Логин";
					}
					else if (model.account.password.Length > 20)
					{
						model.FieldName = "Пароль";
					}
					else if (model.patient.name.Length > 20)
					{
						model.FieldName = "Имя";
					}
					else if (model.patient.surname.Length > 20)
					{
						model.FieldName = "Фамилия";
					}
					else if (model.patient.thirdname == null ? false : model.patient.thirdname.Length > 20)
					{
						model.FieldName = "Отчество";
					}
					else
					{
						model.IsFieldOverfilled = false;
						Chamber chamber = _adminRepository.GetChamberById(model.patient.chamberid);
						model.IsChamberOverfilled = _adminRepository.GetAllPatientsInChamber(model.patient.chamberid).ToList().Count + 1 > chamber.capacity;
						if (!model.IsChamberOverfilled)
						{
							_adminRepository.AddAccount(new Account { login = model.account.login, password = model.account.password });
							Account account = _adminRepository.GetAccountsByLogin(model.account.login).ToList()[0];
							_adminRepository.AddPatient(new Patient
							{
								accountid = account.id,
								name = model.patient.name,
								surname = model.patient.surname,
								thirdname = model.patient.thirdname,
								chamberid = model.patient.chamberid,
								rating = model.patient.rating,
							});
						}
					}
					
				}
			}
		    model.IsInputActivate = true;
			model.patients = _adminRepository.GetAllPatients().ToList();
			model.chambers = _adminRepository.GetAllChambers().ToList();
			return View(model);
		}
		[HttpGet]
		public IActionResult PatientsEdit(AllAdminViewModel model)
		{
			model.IsEdit = true;
			StaticStuff.adminmodel = model;
			return RedirectToAction("Patients");
		}
		[HttpPost]
		public IActionResult PatientsEditSubmit(AllAdminViewModel model)
		{
			model.IsEdit = true;
			model.IsFieldEmpty = true;
			if (model.patient.name == null)
			{
				model.FieldName = "Имя";
			}
			else if (model.patient.surname == null)
			{
				model.FieldName = "Фамилия";
			}
			else
			{
				model.IsFieldEmpty = false;
				model.IsFieldOverfilled = true;
				if (model.patient.name.Length > 20)
				{
					model.FieldName = "Имя";
				}
				else if (model.patient.surname.Length > 20)
				{
					model.FieldName = "Фамилия";
				}
				else if (model.patient.thirdname == null ? false : model.patient.thirdname.Length > 20)
				{
					model.FieldName = "Отчество";
				}
				else
				{
					model.IsFieldOverfilled = false;
					Chamber chamber = _adminRepository.GetChamberById(model.patient.chamberid);
					model.IsChamberOverfilled = _adminRepository.GetAllPatientsInChamber(model.patient.chamberid).ToList().Count + 1 > chamber.capacity
						&& _adminRepository.GetPatientById(model.patient.id).chamberid != model.patient.chamberid;
					if (!model.IsChamberOverfilled)
					{
						Patient patient_update = _adminRepository.GetPatientById(model.patient.id);
						patient_update.name = model.patient.name;
						patient_update.surname = model.patient.surname;
						patient_update.thirdname = model.patient.thirdname;
						patient_update.rating = model.patient.rating;
						patient_update.chamberid = model.patient.chamberid;
						patient_update.chamber = chamber;
						_adminRepository.UpdatePatient(patient_update);
						model.IsEdit = false;
					}
				}
			}
			StaticStuff.adminmodel = model;
			return RedirectToAction("Patients");
		}
		public IActionResult AddPatient(AllAdminViewModel model)
		{
			model.IsInputActivate = true;
			StaticStuff.adminmodel = model;
			return RedirectToAction("Patients");
		}
		public IActionResult Doctors()
		{
			AllAdminViewModel model = StaticStuff.adminmodel == null ? new AllAdminViewModel() : StaticStuff.adminmodel;
			model.doctors = _adminRepository.GetAllDoctors().ToList();
			return View(model);
		}
		public IActionResult DoctorsEdit(AllAdminViewModel model)
		{
			model.IsEdit = true;
			StaticStuff.adminmodel = model;
			return RedirectToAction("Doctors");
		}
		[HttpPost]
		public IActionResult DoctorsEditSubmit(AllAdminViewModel model)
		{
			model.IsEdit = true;
			model.IsFieldEmpty = true;
			if (model.doctor.name == null)
			{
				model.FieldName = "Имя";
			}
			else if (model.doctor.surname == null)
			{
				model.FieldName = "Фамилия";
			}
			else if (model.doctor.specialization == null)
			{
				model.FieldName = "Специализация";
			}
			else if (model.doctor.phonenumber == null)
			{
				model.FieldName = "Телефон";
			}
			else
			{
				model.IsFieldEmpty = false;
				model.IsFieldOverfilled = true;
				if (model.doctor.name.Length > 20)
				{
					model.FieldName = "Имя";
				}
				else if (model.doctor.surname.Length > 20)
				{
					model.FieldName = "Фамилия";
				}
				else if (model.doctor.thirdname == null ? false : model.doctor.thirdname.Length > 20)
				{
					model.FieldName = "Отчество";
				}
				else if (model.doctor.specialization.Length > 50)
				{
					model.FieldName = "Специализация";
				}
				else if (model.doctor.phonenumber.Length > 12)
				{
					model.FieldName = "Телефон";
				}
				else
				{
					model.IsFieldOverfilled = false;
					Doctor doctor_update = _adminRepository.GetDoctorById(model.doctor.id);
					doctor_update.name = model.doctor.name;
					doctor_update.surname = model.doctor.surname;
					doctor_update.thirdname = model.doctor.thirdname;
					doctor_update.specialization = model.doctor.specialization;
					doctor_update.cabinetnumber = model.doctor.cabinetnumber;
					doctor_update.phonenumber = model.doctor.phonenumber;
					_adminRepository.UpdateDoctor(doctor_update);
					model.IsEdit = false;
				}
			}
			StaticStuff.adminmodel = model;
			return RedirectToAction("Doctors");
		}
		public IActionResult DoctorPatients(AllAdminViewModel model)
		{
			if (model.doctor == null)
				model = StaticStuff.adminmodel;
			model.patients = _adminRepository.GetPatientsByDoctorId(model.doctor.id).ToList();
			model.chambers = _adminRepository.GetAllChambers().ToList();
			model.allpatients = _adminRepository.GetAllPatients().ToList();
			return View(model);
		}
		[HttpPost]
		public IActionResult AddPatientDoctor(AllAdminViewModel model)
		{
			if(_adminRepository.IsConnectionExisting(model.doctor.id, model.patient.id))
			{
				model.HasPatient = true;
			}
			else
			{
				_adminRepository.AddDoctorPatient(new Doctor_Patient_id { doctorid = model.doctor.id, patientid = model.patient.id });
			}
			StaticStuff.adminmodel = model;
			return RedirectToAction("DoctorPatients");
		}
		[HttpPost]
		public IActionResult DeletePatientDoctor(AllAdminViewModel model)
		{
			Doctor_Patient_id dp = _adminRepository.GetDoctor_Patient_id(model.doctor.id, model.patient.id);
			_adminRepository.DeleteDoctorPatient(dp);
			StaticStuff.adminmodel = model;
			return RedirectToAction("DoctorPatients");
		}
		public IActionResult Schedule(AllAdminViewModel model)
		{
			model.doctors = _adminRepository.GetAllDoctors().ToList();
			model.patients = _adminRepository.GetAllPatients().ToList();
			if(model.doctor == null || model.patient == null? true:model.doctor.id == 0 && model.patient.id == 0)
			{
				model.NoneSchedule = true;
			}
			else if(model.doctor.id == 0 && model.patient.id != 0)
			{
				model.schedules = _adminRepository.GetPatientSchedule(model.patient.id).ToList();
			}
			else if(model.doctor.id != 0 && model.patient.id == 0)
			{
				model.schedules = _adminRepository.GetDoctorSchedule(model.doctor.id).ToList();
			}
			else
			{
				model.schedules = _adminRepository.GetSchedule(model.doctor.id, model.patient.id).ToList();
			}
			return View(model);
		}
	}
	
}
