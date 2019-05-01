<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Task;
use AppBundle\Form\TaskType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class TaskController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
       // TODO: Implement me...
        $repository = $this->getDoctrine()->getRepository(Task::class);
        $openTasks = $repository->findBy(["status" => "Open"]);
        $inProgressTasks = $repository->findBy(["status" => "In Progress"]);
        $finishedTasks = $repository->findBy(["status" => "Finished"]);

        return $this
            ->render(':task:index.html.twig',
            [
                "openTasks" => $openTasks,
                "inProgressTasks" => $inProgressTasks,
                "finishedTasks" => $finishedTasks
            ]);
    }

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        // TODO: Implement me...

        $taskToCreate = new Task();

        $form = $this->createForm(TaskType::class, $taskToCreate);

        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {

            if ($taskToCreate->getTitle() == null) {
                return $this->redirectToRoute('index');
            }

            if ($taskToCreate->getTitle() != "") {
                $em = $this->getDoctrine()->getManager();
                $em->persist($taskToCreate);
                $em->flush();
            }

            return $this->redirectToRoute('index');
        }

        return $this->render('task/create.html.twig', ['form' => $form->createView()]);
    }

    /**
     * @Route("/edit/{id}", name="edit")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function edit($id, Request $request)
    {
       // TODO: Implement me...

        $taskToEdit = $this->getDoctrine()->getRepository(Task::class)->find($id);

        if ($taskToEdit == null) {
            return $this->redirectToRoute('index');
        }

        $form = $this->createForm(TaskType::class, $taskToEdit);

        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {

            $em = $this->getDoctrine()->getManager();
            $em->merge($taskToEdit);
            $em->flush();

            return $this->redirectToRoute('index');
        }

        return $this->render('task/edit.html.twig', ['task' => $taskToEdit, 'form' => $form->createView()]);
    }
}
