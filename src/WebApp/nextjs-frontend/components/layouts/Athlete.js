import React from "react";
import DefaultLeftPane from "../reusable-comps/default-left-pane";
import style from "../../styles/athlete-main-page.module.css";


function Athlete({ user, loading = false, children }) {
  return (
    <>
      <div className={style.container}>
        <div style={{ borderRight: "1px solid #D0D5DD", width: "350px" }}>
          <DefaultLeftPane />
        </div>
        {children}
      </div>
    </>
  );
}

export default Athlete;
