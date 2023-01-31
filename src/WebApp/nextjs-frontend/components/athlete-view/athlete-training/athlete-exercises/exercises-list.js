import style from "./exercise-list.module.css";
import React from "react";
import Link from "next/link";
import Button from "../../../reusable-comps/button";

const ExercisesList = ({exercises}) => {

    console.log(exercises);

    return (
        <div className={style.container}>
            <div className={style.header}>
                <h2>Exercises</h2>
                <p>Manage your exercises here.</p>
            </div>
            <div className={style.tableContainer}>
                <div className={style.header}>
                    <div className={style.info}>
                        <div>
                            <h4><b>Exercise</b></h4>
                        </div>
                        <div style={{marginBottom: "0.75rem"}}>
                            <Link href="/add-new-exercise">
                                <Button iconSrc="/thumbnails/add-outline.svg" text="Add new"
                                        backgroundColorValue="#8098F9"
                                        borderValue="none"
                                        isHoveringColor="#C7D7FE"
                                        extraStyleType="color"
                                        extraStyleValue="white"
                                />
                            </Link>
                        </div>
                    </div>
                </div>
                <div>
                    <table className={style.tableOfTrainings}>
                        <thead className={style.tHead}>
                        <tr>
                            <th className={style.thRegular}>Name</th>
                            <th className={style.thRegular}>Body Part</th>
                            <th className={style.thRegular}>Category</th>
                            <th className={style.thRegular}>Action</th>
                        </tr>
                        </thead>
                        <tbody className={style.tBody}>
                        {exercises.map(exercise => {
                            return (
                                <tr key={exercise.id}>
                                    <td className={style.tdRegular}>{exercise.name}</td>
                                    <td className={style.tdRegular}>
                                        <div className={style.infoProgress} style={{backgroundColor: "#F9F5FF",
                                            color: "#98B3DB"
                                        }}>{exercise.category}
                                        </div>
                                    </td>
                                    <td className={style.tdRegular}>{exercise.category}</td>
                                    <td className={style.tdRegular} style={{padding:"0"}}>
                                        <Button iconSrc="/thumbnails/copy-outline.svg"
                                                backgroundColorValue="white"
                                                isHoveringColor="#D0D5DD"
                                                borderValue="none"
                                        />
                                        <Button iconSrc="/thumbnails/modify.svg"
                                                backgroundColorValue="white"
                                                isHoveringColor="#D0D5DD"
                                                borderValue="none"
                                        />
                                        <Button iconSrc="/thumbnails/trash-bin-outline.svg"
                                                backgroundColorValue="white"
                                                isHoveringColor="#D0D5DD"
                                                borderValue="none"
                                        />
                                    </td>
                                </tr>
                            );
                        })}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}

export default ExercisesList;