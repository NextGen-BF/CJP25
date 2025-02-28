import { FC } from "react";
import RequestTable from "../../components/Request/RequestsTable";

const RequestsListPage: FC = () => {
  return (
    <>
      <h1>Request Lists Page</h1>
      {/* Clicking on request will open up modal with additional info plus a link to the files linked with the request*/}
      <div>
        <RequestTable />
      </div>
    </>
  );
};
export default RequestsListPage;
