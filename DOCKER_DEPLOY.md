# Docker Deployment on RHEL

Deploy the Software Subscription App using Docker on a Red Hat Enterprise Linux VM, accessible at **dayan3.devtscape.org**.

## Prerequisites on RHEL VM

```bash
# Install Docker (RHEL 8/9)
sudo dnf config-manager --add-repo https://download.docker.com/linux/rhel/docker-ce.repo
sudo dnf install -y docker-ce docker-ce-cli containerd.io docker-compose-plugin

# Enable and start Docker
sudo systemctl enable docker
sudo systemctl start docker
sudo usermod -aG docker $USER
# Log out and back in, or: newgrp docker
```

## DNS

Point **dayan3.devtscape.org** to your RHEL VM's public IP (A record).

## Deploy

```bash
# Clone or copy project to VM, then:
cd SoftwareSubscriptionApp

# Copy env example (optional - defaults work)
cp .env.example .env

# Build and run
docker compose up -d --build
```

The app creates tables and seeds default users (admin/Admin@123, user/User@123) on first run.

## Commands

```bash
# Start
docker compose up -d

# View logs
docker compose logs -f

# Stop
docker compose down

# Rebuild after code changes
docker compose up -d --build
```

## Access

- **URL:** http://dayan3.devtscape.org (or https after SSL setup)
- **Login:** admin / Admin@123 (Admin) or user / User@123 (User)

## HTTPS (Let's Encrypt) with Traefik

1. Uncomment the TLS labels on the `app` service in `docker-compose.yml`.
2. Uncomment the Let's Encrypt commands and volume in the `traefik` service.
3. Set `YOUR_EMAIL` in the acme.email option.
4. Uncomment `traefik_certs` volume and the `traefik.http.routers.app.entrypoints=websecure` / `tls` labels.
5. Restart: `docker compose up -d --build`

## Environment variables

| Variable | Default | Description |
|----------|---------|-------------|
| MYSQL_ROOT_PASSWORD | MyRootPass123 | MySQL root password |
| MYSQL_USER | appuser | App DB user |
| MYSQL_PASSWORD | AppPass123 | App DB password |
