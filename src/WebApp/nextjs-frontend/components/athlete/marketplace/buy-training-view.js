import style from "./buy-training-view.module.css";
import React from "react";
import Image from "next/image";
import Link from "next/link";
import {Rating, Typography} from "@mui/material";
import Button from "../../reusable/button";
import TrainingPreview from "../training/training-plans/training-preview";
import BuyPlanModal from "../modals/buy-plan-modal";

const BuyTrainingView = ({plan}) => {
    return (
        <div className={style.container}>
            <div className={style.header}>
                <h3>Marketplace</h3>
                <div className={style.mainImage}/>
            </div>
            <div className={style.content}>
                <div className={style.midHeader}>
                    <div style={{marginBottom: "1rem"}}>
                        <Link href='/athlete/marketplace'>
                            <Button
                                iconSrc='/thumbnails/arrow-back-outline.svg'
                                text='Browse more plans'
                                borderValue='none'
                                backgroundColorValue='white'
                                isHoveringColor='#C7D7FE'
                                extraStyleType='color'
                                extraStyleValue='#8098F9'
                            />
                        </Link>
                    </div>
                    <h2>{plan.title}</h2>
                </div>
                <div className={style.details}>
                    <h5>Length: {plan.duration} weeks</h5>
                    <h5>Number of workouts: {plan.noOfWorkouts}</h5>
                    <h5>Skill level: {plan.skillLevel}</h5>
                    <div className={style.description}>
                        <div>
                            <h5>Plan description</h5>
                            <p>{plan.description}</p>
                        </div>
                        <div>
                            <div className={style.bottomSection}>
                                <Link
                                    href={{
                                        pathname: `/athlete/marketplace/creator`,
                                        query: {
                                            creatorEmail: plan.creatorEmail,
                                            id: plan.id,
                                            goBack: `/athlete/marketplace/plan`,
                                        },
                                    }}
                                    style={{textDecoration: "none"}}
                                >
                                    <div className={style.userInfo}>
                                        <Image
                                            className={style.avatar}
                                            src='/avatar-svgrepo-com.svg'
                                            alt='dadas'
                                            width={30}
                                            height={30}
                                        />
                                        <div>
                                            <h5>Creator</h5>
                                            <p>{plan.creatorEmail}</p>
                                        </div>
                                    </div>
                                </Link>
                            </div>
                        </div>
                    </div>
                    <h5 style={{color: "#8098F9", marginBottom: "1rem"}}>Workouts</h5>
                </div>
                <div className={style.bottom}>
                    <div className={style.trainings}>
                        {plan.workouts.map((workout) => {
                            return (
                                <div style={{width: "30%"}} key={workout.id}>
                                    <TrainingPreview workout={workout}/>
                                </div>
                            );
                        })}
                    </div>
                    <div className={style.rightBottom}>
                        <div className={style.rating}>
                            <p style={{marginTop: "1rem"}}>Rating</p>
                            <Typography component='legend'/>
                            <Rating
                                name='simple-controlled'
                                value={plan.ratingAvg}
                                disabled={true}
                            />
                            <p style={{marginTop: "1rem"}}>
                                {plan.ratingsApplied}
                                {plan.ratingsApplied === 1 ? ` review` : " reviews"}
                            </p>
                        </div>
                        <div className={style.apply}>
                            <h5 style={{textAlign: "center", marginRight: "1rem"}}>
                                {plan.price}$
                            </h5>
                            <BuyPlanModal
                                trainingPlan={plan}
                                borderValue='none'
                                backgroundColorValue='#8098F9'
                                isHoveringColor='#C7D7FE'
                                extraStyleType='color'
                                extraStyleValue='white'
                            ></BuyPlanModal>
                            {/* <Button
                iconSrc='/thumbnails/checkmark-outline.svg'
                text='Buy plan'
                borderValue='none'
                backgroundColorValue='#8098F9'
                isHoveringColor='#C7D7FE'
                extraStyleType='color'
                extraStyleValue='white'
              /> */}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default BuyTrainingView;
