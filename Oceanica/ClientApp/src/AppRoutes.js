import { default as Vessel } from "./components/Vessel";
import { default as Contract } from "./components/Contract";

const AppRoutes = [
  {
    index: true,
    element: <Vessel />
  },
  {
    path: '/Contract',
    element: <Contract />
  }
];

export default AppRoutes;
