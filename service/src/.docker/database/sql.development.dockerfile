FROM mcr.microsoft.com/mssql/server:2017-CU20-ubuntu-16.04

# Create a config directory
RUN mkdir -p /usr/config
WORKDIR /usr/config

# Bundle config source
COPY .docker/database/setup.sql /usr/config/setup.sql
COPY .docker/database/entrypoint.sh /usr/config/entrypoint.sh
COPY .docker/database/configure-db.sh /usr/config/configure-db.sh

# Grant permissions for to our scripts to be executable
RUN chmod +x /usr/config/entrypoint.sh
RUN chmod +x /usr/config/configure-db.sh

ENTRYPOINT ["./entrypoint.sh"]

# Tail the setup logs to trap the process
CMD ["tail -f /dev/null"]

HEALTHCHECK --interval=15s CMD /opt/mssql-tools/bin/sqlcmd -U sa -P $SA_PASSWORD -Q "select 1" && grep -q "MSSQL CONFIG COMPLETE" ./config.log