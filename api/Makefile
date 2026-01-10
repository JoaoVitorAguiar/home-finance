migrate:
	dotnet ef migrations add $(name) \
		--project ./HomeFinance.Infra/HomeFinance.Infra.csproj \
		--startup-project ./HomeFinance.Api/HomeFinance.Api.csproj \
		--output-dir Migrations

update-db:
	dotnet ef database update \
		--project ./HomeFinance.Infra/HomeFinance.Infra.csproj \
		--startup-project ./HomeFinance.Api/HomeFinance.Api.csproj
