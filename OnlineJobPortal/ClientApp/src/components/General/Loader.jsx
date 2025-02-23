import { PropagateLoader } from "react-spinners";

const Loader = () => {
  return (
    <div
      style={{
        position: "absolute",
        top: 0,
        left: 0,
        bottom: 0,
        right: 0,
        height: "100%",
        width: "100%",
        color: "whitesmoke",
        opacity: "0.2",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        zIndex: "2000",
      }}
    >
      <PropagateLoader color="blue" />
    </div>
  );
};
export default Loader;
