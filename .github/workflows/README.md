# CI/CD Workflows for Frontend and Backend Docker Images

This repository contains GitHub Actions workflows to build and push Docker images for both the **frontend** and **backend** services. The images are published to GitHub Container Registry (GHCR) with separate version tags for each service.

## Overview

There is a single workflow file that handles both services by inspecting the pushed Git tag. The workflow differentiates the build target based on the tag prefix:
- **Frontend**: Tags starting with `frontend-v`
- **Backend**: Tags starting with `backend-v`

Each image is built from a dedicated directory:
- `./NextGen-BM-BE` for the Frontend service.
- `./NextGen-BM-FE` for the Backend service.

## How to Use
### Tagging Your Release

To trigger the build for a particular service, create and push a Git tag with the appropriate prefix:

- **For Frontend:**
  ```bash
  git tag frontend-v0.0.1
  git push origin frontend-v0.0.1
  
- **For Backend:**
  ```bash
  git tag backend-v0.0.1
  git push origin backend-v0.0.1

## Viewing the Pipeline Executions
Once a tag is pushed, GitHub Actions will automatically start the build process. You can monitor the workflow execution:

1. Go to the repository on GitHub.
2. Click on the **"Actions"** tab at the top.
3. Look for the workflow run associated with the pushed tag.
4. Click on the latest run to see logs, build steps, and outputs.
5. You can verify whether the image was built and pushed successfully from the logs.

## Accessing the Published Docker Images

The built images are stored in **GitHub Container Registry (GHCR)**. You can find them:
1. Click on the **"Packages"** tab
3. You will see the published Docker images:
   - `cjp25-frontend`
   - `cjp25-backend`

# How to Deploy
Follow these steps to deploy your application:
- Access the Deploy Repository
- Navigate to the folder `deployments/cjp-apps`
- Choose the service you wish to deploy (either **backend** or **frontend**).
- Edit the Values File
   - Open the values file corresponding to the desired environment. For example, for the backend in QA, open:
     ```
     deployments/cjp-apps/backend/values-qa.yaml
     ```
   - Modify the image tag to the version you want to deploy:
     ```yaml
     image:
       tag: "0.0.1"
     ```

- Commit and Push Changes
- Sync in ArgoCD
   - Open ArgoCD.
   - Select the corresponding application.
   - Click **Sync** to apply the new deployment.

## Adding New Environment Parameters

1. Navigate to the values file for the specific service and environment where you want to add a parameter.
2. Locate the `env` section in the file.
3. Add your new parameter using the following format:

```yaml
env:
  - name: YOUR_PARAMETER_NAME
    value: YOUR_PARAMETER_VALUE
```