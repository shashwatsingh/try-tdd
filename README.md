
Scope of the app:

- quiz-master can create a quiz
	manage questions: create/update/delete questions & their choices & pick right answer
	manage participants: add via link, remove
	
- quiz-master will control the quiz-run: 
	start, 
	show question, show question choices, next/prev question, show scores
	end

- realtime, all participants see the current state of a quiz run

------------------

C# and Blazor aspects

Designing the model

Designing the UI wrapper for it


shashwat creates a quiz: "blazor"
shashwat adds 2 questsions in this q
shashwat invites Omkar and Adarsh to "blazor" quiz
when the quiz starts:
    for q1: omkar says a, adarsh says b
    for q2: omkar says c, adarsh says c
    end: Omkar 1, Adarsh 1
quiz ends

shashwat starts "blazor"quiz again:
and invites Malini and Annie
when quiz starts:
    for q1: malini says a, annie says b
    for q2: malini says c, annie says c
    end: malini 1, annie 1
quiz ends


---------



/*
{
    tenants: {
        cust1: { // Shashwat's tenant
            owner: {
                id: string,
                name: string,
                email: string
            },
            participants: [
                { name, email }
            ],

            quizList: [
                {
                    name: string,
                    questions: [
                        {
                            text, 
                            answers: [
                                { 
                                    id: string,
                                    text: string,
                                }
                            ],
                            answerId: string
                        }
                    ]
                }
            ],

            runs: [
                {
                    id: string,
                    quizId: string,
                    answers: [
                        {participantid, questionid, answerid, time}
                    ],
                    partcipants: number[], // participantId[]

                }
            ]
        },
        cust2:{ // Adarsh's tenant

        }
    }
}


*/












/*

// Manage creating/maintaining a tenant
ITenantManager
    - creating a tenant properly (having valid tenant properties)
    - finding a tenant given an ownerEmail



IQuizManager(ITenantManager)
    - Create/Update quiz
    - Create/Update questions inside a quiz
        has text, has answers, has correctAnswer
    - Delete a quiz if there are no runs for it. Also delete related questions.
    - Delete a question if there are no runs for the quiz
    - Get saved questions


IQuizRunManager(ITenantManager, IQuizManager)
    - Create a new run
    - Invite participants in a run
    - Participants can join an existing run, that is active
    - Participants can submit their answer


*/
