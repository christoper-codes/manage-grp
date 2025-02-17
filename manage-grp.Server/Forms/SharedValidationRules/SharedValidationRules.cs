using FluentValidation;
using manage_grp.Server.Services;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using manage_grp.Server.Domain.Services;
using manage_grp.Server.Models;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace manage_grp.Server.Forms
{
    public static class SharedValidationRules
    {
        public static IRuleBuilderOptions<T, T> AtLeastOneSelected<T>(
            this IRuleBuilderInitial<T, T> ruleBuilder,
            StateService stateService,
            MunicipalityService municipalityService,
            DependencyService dependencyService,
            params Func<T, int?>[] selectors)
        {
            return (IRuleBuilderOptions<T, T>)ruleBuilder.CustomAsync(async (instance, context, cancellation) =>
            {
                var tasks = selectors.Select(async selector =>
                {
                    var value = selector(instance);

                    if (!value.HasValue || value.Value <= 0)
                    {
                        return false;
                    }

                    if (selector == selectors[0])
                    {
                        return await stateService.GetByIdAsync(value.Value) != null;
                    }
                    else if (selector == selectors[1])
                    {
                        return await municipalityService.GetByIdAsync(value.Value) != null;
                    }
                    else
                    {
                        return await dependencyService.GetByIdAsync(value.Value) != null;
                    }
                });

                var results = await Task.WhenAll(tasks);

                if (!results.Any(result => result))
                {
                    context.AddFailure("Al menos uno de los campos 'Estado', 'Municipio' o 'Dependencia' debe ser un válido y existente.");
                }
            });
        }

        public static IRuleBuilderOptions<T, int> ValidateStateField<T>(this IRuleBuilder<T, int> ruleBuilder, StateService stateService)
        {
            return ruleBuilder.MustAsync(async (StateId, cancellation) =>
            {
                try
                {
                    var state = await stateService.GetByIdAsync(StateId);

                    return state == null;
                }
                catch (KeyNotFoundException)
                {
                    return false;
                }
            }).WithMessage("El campo 'Estado' debe contener un valor válido.");
        }

        public static IRuleBuilderOptions<T, int> ValidateMunicipalityIdField<T>(this IRuleBuilder<T, int> ruleBuilder, MunicipalityService municipalityService)
        {
            return ruleBuilder.MustAsync(async (MunicipalityId, cancellation) =>
            {
                try
                {
                    var municipality = await municipalityService.GetByIdAsync(MunicipalityId);

                    return municipality == null;
                }
                catch (KeyNotFoundException)
                {
                    return false;
                }
            }).WithMessage("El campo 'Municipio' debe contener un valor válido.");
        }

        public static IRuleBuilderOptions<T, int?> ValidateDependencyIdField<T>(this IRuleBuilder<T, int?> ruleBuilder, DependencyService dependencyService)
        {
            return ruleBuilder.MustAsync(async (dependencyId, cancellation) =>
            {
                if (!dependencyId.HasValue) return true;

                try
                {
                    var dependency = await dependencyService.GetByIdAsync((int)dependencyId);

                    return dependency != null;
                }
                catch (KeyNotFoundException)
                {
                    return false;
                }
            }).WithMessage("El campo 'Dependencia' debe contener un valor válido.");
        }

        public static IRuleBuilderOptions<T, int?> ValidateAreaIdField<T>(this IRuleBuilder<T, int?> ruleBuilder, AreaService areaService)
        {
            return ruleBuilder.MustAsync(async (areaId, cancellation) =>
            {
                if (!areaId.HasValue) return true;

                try
                {
                    var area = await areaService.GetByIdAsync((int)areaId);

                    return area != null;
                }
                catch (KeyNotFoundException)
                {
                    return false;
                }
            }).WithMessage("El campo 'area' debe contener un valor válido.");
        }

        public static IRuleBuilderOptions<T, int> ValidateContactIdField<T>(this IRuleBuilder<T, int> ruleBuilder, ContactService contactService)
        {
            return ruleBuilder.MustAsync(async (ContactId, cancellation) =>
            {
                try
                {
                    var contact = await contactService.GetByIdAsync(ContactId);

                    return contact != null;
                }
                catch (KeyNotFoundException)
                {
                    return false;
                }
            }).WithMessage("El campo 'Contacto' debe contener un valor válido.");
        }

        public static IRuleBuilderOptions<T, int> ValidatePositionIdField<T>(this IRuleBuilder<T, int> ruleBuilder, PositionService positionService)
        {
            return ruleBuilder.MustAsync(async (PositionId, cancellation) =>
            {
                try
                {
                    var position = await positionService.GetByIdAsync(PositionId);

                    return position == null;
                }
                catch (KeyNotFoundException)
                {
                    return false;
                }
            }).WithMessage("El campo 'Posición' debe contener un valor válido.");
        }

        public static IRuleBuilderOptions<T, int?> ValidateBudgetaryKeyIdField<T>(this IRuleBuilder<T, int?> ruleBuilder, BudgetaryKeyService budgetaryKeyService)
        {
            return ruleBuilder.MustAsync(async (BudgetaryKeyId, cancellation) =>
            {
                if (!BudgetaryKeyId.HasValue) return true;

                try
                {
                    var documentRequirement = await budgetaryKeyService.GetByIdAsync((int)BudgetaryKeyId);

                    return documentRequirement != null;
                }
                catch (KeyNotFoundException)
                {
                    return false;
                }
            }).WithMessage("El campo 'Dependencia' debe contener un valor válido.");
        }

        public static IRuleBuilderOptions<T, int> ValidateDocumentRequirementIdField<T>(this IRuleBuilder<T, int> ruleBuilder, DocumentRequirementService documentRequirementService)
        {
            return ruleBuilder.MustAsync(async (DocumentRequirementId, cancellation) =>
            {
                try
                {
                    var documentRequirement = await documentRequirementService.GetByIdAsync(DocumentRequirementId);

                    return documentRequirement != null;
                }
                catch (KeyNotFoundException)
                {
                    return false;
                }
            }).WithMessage("El campo 'Dependencia' debe contener un valor válido.");
        }

        public static IRuleBuilderOptions<T, int> ValidateDocumentRequirementIdField<T>(this IRuleBuilder<T, int> ruleBuilder, BudgetaryKeyDocumentTypeService budgetaryKeyDocumentTypeService)
        {
            return ruleBuilder.MustAsync(async (BudgetaryKeyDocumentTypeId, cancellation) =>
            {
                try
                {
                    var budgetaryKeyDocumentType = await budgetaryKeyDocumentTypeService.GetByIdAsync(BudgetaryKeyDocumentTypeId);

                    return budgetaryKeyDocumentType != null;
                }
                catch (KeyNotFoundException)
                {
                    return false;
                }
            }).WithMessage("El campo 'Clave presupuestal' y 'Tipo de documento' debe contener un valor válido.");
        }

        public static IRuleBuilderOptions<T, string> ValidateMimeTypeField<T>(this IRuleBuilder<T, string> ruleBuilder, string fieldName)
        {
            return ruleBuilder
                .NotNull().WithMessage($"El campo '{fieldName}' no debe ser nulo.")
                .NotEmpty().WithMessage($"El campo '{fieldName}' no debe estar vacío.")
                .Matches(@"^[a-zA-Z0-9]+\/[a-zA-Z0-9\-\+\.]+$").WithMessage($"El campo '{fieldName}' debe tener un formato MIME type válido.");
        }

        public static IRuleBuilderOptions<T, string> ValidateRfcField<T>(this IRuleBuilder<T, string> ruleBuilder, string fieldName)
        {
            return ruleBuilder
                .NotNull().WithMessage($"El campo '{fieldName}' no debe ser nulo.")
                .NotEmpty().WithMessage($"El campo '{fieldName}' no debe estar vacío.")
                .Matches(@"^[A-ZÑ&]{3,4}\d{6}[A-Z\d]{3}$").WithMessage($"El campo '{fieldName}' debe tener una estructura válida de RFC.");
        }

        public static IRuleBuilderOptions<T, string> ValidateEmailContactField<T>(this IRuleBuilder<T, string> ruleBuilder, ContactService contactService)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .NotNull().WithMessage("El correo electrónico no puede ser nulo.")
                .EmailAddress().WithMessage("El correo electrónico no tiene un formato válido.")
                .MustAsync(async (Email, cancellation) =>
                {
                    try
                    {
                        var position = await contactService.GetByEmailAsync(Email);

                        return position != null;
                    }
                    catch (KeyNotFoundException)
                    {
                        return false;
                    }
                }).WithMessage("El correo electrónico ya está registrado.");
        }

        public static IRuleBuilderOptions<T, string> ValidateEmailUserField<T>(this IRuleBuilder<T, string> ruleBuilder, UserService userService)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
                .NotNull().WithMessage("El correo electrónico no puede ser nulo.")
                .EmailAddress().WithMessage("El correo electrónico no tiene un formato válido.")
                .MustAsync(async (Email, cancellation) =>
                {
                    try
                    {
                        var user = await userService.GetByEmailAsync(Email);

                        return user == null;
                    }
                    catch (KeyNotFoundException)
                    {
                        return false;
                    }
                }).WithMessage("El correo electrónico ya está registrado.");
        }

        public static IRuleBuilderOptions<T, DateTime> ValidateDateField<T>(this IRuleBuilder<T, DateTime> ruleBuilder, string fieldName)
        {
            return ruleBuilder
                .NotNull().WithMessage($"El campo '{fieldName}' es obligatorio.")
                .Must(date => date != default(DateTime))
                .WithMessage($"El campo '{fieldName}' debe ser una fecha válida.");
        }

        public static IRuleBuilderOptions<T, string> ValidatePhoneField<T>(this IRuleBuilder<T, string> ruleBuilder, string fieldName)
        {
            return ruleBuilder
                .NotNull().WithMessage($"El campo '{fieldName}' no debe ser nulo.")
                .NotEmpty().WithMessage($"El campo '{fieldName}' no debe estar vacío.")
                .Matches(@"^\+?\d{10,15}$").WithMessage($"El campo '{fieldName}' debe tener un formato de número de teléfono válido.");
        }

        public static IRuleBuilderOptions<T, string> ValidatePassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("La 'Contraseña' es obligatoria.")
                .MinimumLength(6).WithMessage("La 'Contraseña' debe tener al menos 6 caracteres.")
                .Matches(@"[A-Z]").WithMessage("La 'Contraseña' debe tener al menos una letra mayúscula ('A'-'Z').")
                .Matches(@"[0-9]").WithMessage("La 'Contraseña' debe tener al menos un número ('0'-'9').")
                .Matches(@"[\W_]").WithMessage("La 'Contraseña' debe tener al menos un carácter no alfanumérico.");
        }

        public static IRuleBuilderOptions<T, TDto> ValidateLocation<T, TDto>(this IRuleBuilder<T, TDto> ruleBuilder, Func<TDto, string> latitudeSelector, Func<TDto, string> longitudeSelector)
        {
            return ruleBuilder.Must(location => 
            {
                if (location == null) {
                    return false;
                };

                string latitude = latitudeSelector(location);
                string longitude = longitudeSelector(location);

                return IsValidLatitude(latitude) && IsValidLongitude(longitude);
            })
            .WithMessage("La latitud debe estar en el rango de -90 a 90 y la longitud en el rango de -180 a 180, con un formato válido.");
        }

        public static IRuleBuilderOptions<T, string> ValidateStringField<T>(this IRuleBuilder<T, string> ruleBuilder, string fieldName, int maxLength)
        {
            return ruleBuilder
                .NotNull().WithMessage($"El campo '{fieldName}' no debe ser nulo.")
                .NotEmpty().WithMessage($"El campo '{fieldName}' no debe estar vacío.")
                .MaximumLength(maxLength).WithMessage($"El campo '{fieldName}' no debe tener más de {maxLength} caracteres.");
        }

        public static IRuleBuilderOptions<T, string> ValidateStringLength<T>(this IRuleBuilder<T, string> ruleBuilder, string fieldName, int length)
        {
            return ruleBuilder
                .Matches($@"^\d{{{length}}}$").WithMessage($"El campo '{fieldName}' debe tener {length} caracteres.");
        }

        public static IRuleBuilderOptions<T, int> ValidateNumericIntField<T>(this IRuleBuilder<T, int> ruleBuilder, string fieldName, int? minValue = null, int? maxValue = null)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage($"El campo '{fieldName}' no debe estar vacío.")
                .NotNull().WithMessage($"El campo '{fieldName}' no debe ser nulo.");

            if (minValue.HasValue)
            {
                options = options.GreaterThanOrEqualTo(minValue.Value).WithMessage($"El campo '{fieldName}' debe ser mayor o igual a {minValue.Value}.");
            }

            if (maxValue.HasValue)
            {
                options = options.LessThanOrEqualTo(maxValue.Value).WithMessage($"El campo '{fieldName}' no debe ser mayor que {maxValue.Value}.");
            }

            return options;
        }

        public static IRuleBuilderOptions<T, decimal> ValidateNumericDecimalField<T>(this IRuleBuilder<T, decimal> ruleBuilder, string fieldName, decimal? minValue = null, decimal? maxValue = null)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage($"El campo '{fieldName}' no debe estar vacío.")
                .NotNull().WithMessage($"El campo '{fieldName}' no debe ser nulo.");

            if (minValue.HasValue)
            {
                options = options.GreaterThanOrEqualTo(minValue.Value).WithMessage($"El campo '{fieldName}' debe ser mayor o igual a {minValue.Value}.");
            }

            if (maxValue.HasValue)
            {
                options = options.LessThanOrEqualTo(maxValue.Value).WithMessage($"El campo '{fieldName}' no debe ser mayor que {maxValue.Value}.");
            }

            return options;
        }

        public static IRuleBuilderOptions<T, long> ValidateNumericLongField<T>(this IRuleBuilder<T, long> ruleBuilder, string fieldName, long? minValue = null, long? maxValue = null)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage($"El campo '{fieldName}' no debe estar vacío.")
                .NotNull().WithMessage($"El campo '{fieldName}' no debe ser nulo.");

            if (minValue.HasValue)
            {
                options = options.GreaterThanOrEqualTo(minValue.Value).WithMessage($"El campo '{fieldName}' debe ser mayor o igual a {minValue.Value}.");
            }

            if (maxValue.HasValue)
            {
                options = options.LessThanOrEqualTo(maxValue.Value).WithMessage($"El campo '{fieldName}' no debe ser mayor que {maxValue.Value}.");
            }

            return options;
        }

        public static IRuleBuilderOptions<T, object> ValidateObjectOrString<T>(this IRuleBuilder<T, object> ruleBuilder, string fieldName)
        {
            return ruleBuilder
                .NotNull().WithMessage($"El campo '{fieldName}' no debe ser nulo.")
                .NotEmpty().WithMessage($"El campo '{fieldName}' no debe estar vacío.")
                .Must(value => IsValidObjectOrJsonString(value)).WithMessage($"El campo '{fieldName}' debe ser un objeto válido o una cadena JSON válida.");
        }

        private static bool IsValidObjectOrJsonString(object value)
        {
            if (value is string stringValue)
            {
                return IsValidJson(stringValue);
            }

            return true;
        }

        private static bool IsValidJson(string value)
        {
            value = value.Trim();

            if ((value.StartsWith("{") && value.EndsWith("}")) ||(value.StartsWith("[") && value.EndsWith("]")))
            {
                try
                {
                    JToken.Parse(value);

                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
            }

            return false;
        }

        private static bool IsValidLatitude(string latitude)
        {
            if (string.IsNullOrWhiteSpace(latitude)) return false;

            if (double.TryParse(latitude, out double lat))
            {
                return lat >= -90 && lat <= 90;
            }

            return false;
        }

        private static bool IsValidLongitude(string longitude)
        {
            if (string.IsNullOrWhiteSpace(longitude)) return false;

            if (double.TryParse(longitude, out double lon))
            {
                return lon >= -180 && lon <= 180;
            }

            return false;
        }
    }
}