1. **Execute Docker Compose:**
   - Navigate to the `DemoApp` folder in your terminal.
   - Run the following command to start the containers for the API and Database (PostgreSQL):

     ```bash
     docker-compose up
     ```

   This will create the necessary containers.

2. **Database Initialization Script:**
   - The setup includes a script to create tables and insert four records. This script is designed to execute only once. If you need to reprocess, you must delete or purge the volume associated with the containers.

3. **Volume Management:**
   - To delete/purge the volume, use the following command:

     ```bash
     docker-compose down -v
     ```

4. **Network Configuration:**
   - A network has been configured to facilitate communication between the API and the Database.

Please note that these instructions assume you have Docker and Docker Compose installed on your machine.


