

# docker

sudo apt-get update

sudo apt-get install -y docker.io

sudo systemctl enable --now docker


#docker volume create portainer_data
docker run -d -p 9000:9000 --name portainer --restart=always -v /var/run/docker.sock:/var/run/docker.sock -v portainer_data:/data portainer/portainer-ce


sudo apt-get update
sudo apt-get install -y docker.io

admin123456789

docker restart portainer