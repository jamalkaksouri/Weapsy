using System.Collections.Generic;
using FluentValidation;
using Weapsy.Infrastructure.Domain;
using Weapsy.Domain.Apps.Commands;

namespace Weapsy.Domain.Apps.Handlers
{
    public class CreateAppHandler : ICommandHandler<CreateApp>
    {
        private readonly IAppRepository _appRepository;
        private readonly IValidator<CreateApp> _validator;

        public CreateAppHandler(IAppRepository appRepository,
            IValidator<CreateApp> validator)
        {
            _appRepository = appRepository;
            _validator = validator;
        }

        public IEnumerable<IEvent> Handle(CreateApp command)
        {
            var app = App.CreateNew(command, _validator);

            _appRepository.Create(app);

            return app.Events;
        }
    }
}
